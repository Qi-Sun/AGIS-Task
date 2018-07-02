using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TriangleSet
    {
        public List<Triangle> TriangleList = new List<Triangle>();
        public TriangleSet() { }

        /// <summary>
        /// 移除指定TID的三角形
        /// </summary>
        /// <param name="tid"></param>
        public void RemoveTriangleByTID(int tid)
        {
            int index = 0;
            foreach (var tri in TriangleList)
            {
                if (tri.TID == tid)
                    break;
                index++;
            }
            TriangleList.RemoveAt(index);
        }

        public void AddTriangle(Triangle t)
        {
            TriangleList.Add(t);
        }

        public Triangle GetPointInsidesTri(DataPoint p)
        {
            foreach (var tri in TriangleList)
            {
                if (tri.IsPointInTriangle(p))
                    return tri;
            }
            return null;
        }
        public bool IsTriAlreadyExists(int oid1,int oid2,int oid3)
        {
            foreach (var tri in TriangleList)
            {
                if (tri.IsEqulesTri(oid1,oid2,oid3))
                    return true;
            }
            return false;
        }
    }
}
