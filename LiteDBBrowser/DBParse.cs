using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LiteDBBrowser
{
    internal class DBParse
    {
        internal List<TreeNode> RootNodes { get; private set; } = new List<TreeNode>();

        internal DBParse()
        {
        }

        internal List<string> GetCollections(string fileName, string password = "")
        {
            ConnectionString connStr = new ConnectionString
            {
                Filename = fileName
            };
            if (!string.IsNullOrEmpty(password)) connStr.Password = password;
            using (LiteEngine engine = new LiteEngine(fileName, password))
            using (LiteDatabase db = new LiteDatabase(connStr))
            {
                return db.GetCollectionNames().ToList();
            }
        }

        internal void ParseCollection(TreeNode rootNode, string fileName, string password = "")
        {
            using (LiteEngine engine = new LiteEngine(fileName, password))
            {
                List<BsonDocument> docs = engine.FindAll(rootNode.Text).ToList();
                docs.ForEach(d =>
                {
                    switch (d.Type)
                    {
                        case BsonType.MinValue:
                            rootNode.Nodes.Add(new TreeNode("MinValue"));
                            break;

                        case BsonType.Null:
                            rootNode.Nodes.Add(new TreeNode("Null"));
                            break;

                        case BsonType.Int32:
                            rootNode.Nodes.Add(new TreeNode(d.AsInt32.ToString()));
                            break;

                        case BsonType.Int64:
                            rootNode.Nodes.Add(new TreeNode(d.AsInt64.ToString()));
                            break;

                        case BsonType.Double:
                            rootNode.Nodes.Add(new TreeNode(d.AsDouble.ToString()));
                            break;

                        case BsonType.Decimal:
                            rootNode.Nodes.Add(new TreeNode(d.AsDecimal.ToString()));
                            break;

                        case BsonType.String:
                            rootNode.Nodes.Add(new TreeNode(d.AsString));
                            break;

                        case BsonType.Document:
                            ParseDocument(rootNode, d.AsDocument);
                            break;

                        case BsonType.Array:
                            rootNode.Nodes.Add(new TreeNode("Array"));
                            break;

                        case BsonType.Binary:
                            rootNode.Nodes.Add(new TreeNode("Binary"));
                            break;

                        case BsonType.ObjectId:
                            rootNode.Nodes.Add(new TreeNode(d.AsObjectId.ToString()));
                            break;

                        case BsonType.Guid:
                            rootNode.Nodes.Add(new TreeNode(d.AsGuid.ToString()));
                            break;

                        case BsonType.Boolean:
                            rootNode.Nodes.Add(new TreeNode(d.AsBoolean.ToString()));
                            break;

                        case BsonType.DateTime:
                            rootNode.Nodes.Add(new TreeNode(d.AsDateTime.ToShortDateString()));
                            break;

                        case BsonType.MaxValue:
                            rootNode.Nodes.Add(new TreeNode("MaxValue"));
                            break;

                        default:
                            break;
                    }
                });
            }
        }

        private TreeNode ProcessID(TreeNodeCollection n, BsonValue v, string key)
        {
            string idValue = string.Empty;
            switch (v.Type)
            {
                case BsonType.Int32:
                    idValue = $"Int32: {v.AsInt32.ToString()}";
                    break;

                case BsonType.Int64:
                    idValue = $"Int64: {v.AsInt64.ToString()}";
                    break;

                case BsonType.ObjectId:
                    idValue = $"ObjectID: {v.AsObjectId.ToString()}";
                    break;

                case BsonType.Guid:
                    idValue = $"Guid: {v.AsGuid.ToString()}";
                    break;

                default:
                    break;
            }
            TreeNode primaryKey = new TreeNode($"{key}: {idValue}");
            n.Add(primaryKey);
            return primaryKey;
        }

        private void ParseDocument(TreeNode n, BsonDocument d)
        {
            List<string> keys = d.Keys.ToList();
            TreeNode primaryKey = null;
            if (keys.Contains("_id"))
            {
                keys.Remove("_id");
                primaryKey = ProcessID(n.Nodes, d.RawValue["_id"], "_id");
            }
            else if (keys.Contains("$id"))
            {
                keys.Remove("$id");
                primaryKey = ProcessID(n.Nodes, d.RawValue["$id"], "$id");
            }
            else
            {
                primaryKey = n;
            }
            keys.ForEach(k =>
            {
                TreeNode newNode = new TreeNode(k);
                primaryKey.Nodes.Add(newNode);
                switch (d.RawValue[k].Type)
                {
                    case BsonType.MinValue:
                        newNode.Nodes.Add(new TreeNode("MinValue"));
                        break;

                    case BsonType.Null:
                        newNode.Nodes.Add(new TreeNode("Null"));
                        break;

                    case BsonType.Int32:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsInt32.ToString()));
                        break;

                    case BsonType.Int64:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsInt64.ToString()));
                        break;

                    case BsonType.Double:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsDouble.ToString()));
                        break;

                    case BsonType.Decimal:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsDecimal.ToString()));
                        break;

                    case BsonType.String:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsString));
                        break;

                    case BsonType.Document:
                        ParseDocument(newNode, d.RawValue[k].AsDocument);
                        break;

                    case BsonType.Array:
                        newNode.Nodes.Add(new TreeNode("Array"));
                        break;

                    case BsonType.Binary:
                        newNode.Nodes.Add(new TreeNode("Binary"));
                        break;

                    case BsonType.ObjectId:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsObjectId.ToString()));
                        break;

                    case BsonType.Guid:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsGuid.ToString()));
                        break;

                    case BsonType.Boolean:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsBoolean.ToString()));
                        break;

                    case BsonType.DateTime:
                        newNode.Nodes.Add(new TreeNode(d.RawValue[k].AsDateTime.ToShortDateString()));
                        break;

                    case BsonType.MaxValue:
                        newNode.Nodes.Add(new TreeNode("MaxValue"));
                        break;

                    default:
                        break;
                }
            });
        }
    }
}