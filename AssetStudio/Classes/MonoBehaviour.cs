using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetStudio
{
    public sealed class MonoBehaviour : Behaviour
    {
        public PPtr<MonoScript> m_Script;
        public string m_Name;

        public static AssemblyLoader assemblyLoader = new AssemblyLoader();

        public static List<TypeTreeNode> MonoBehaviourToTypeTreeNodes(MonoBehaviour m_MonoBehaviour)
        {
            if (!assemblyLoader.Loaded)
            {
                assemblyLoader.Load("Managed");
            }
            return m_MonoBehaviour.ConvertToTypeTreeNodes(assemblyLoader);
        }

        public List<TypeTreeNode> TypeTreeNodes
        {
            get
            {
                return MonoBehaviourToTypeTreeNodes(this);
            }
        }


        public MonoBehaviour(ObjectReader reader) : base(reader)
        {
            m_Script = new PPtr<MonoScript>(reader);
            m_Name = reader.ReadAlignedString();
        }
    }
}
