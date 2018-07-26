using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mzl.Common.XMLHelper
{
  public static  class XMLHelper
    {
        public static XmlNode ReadXmlNode(this  string filename,string node)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filename);
                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                XmlNode root = xmlDoc.SelectSingleNode(node);//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
                if (root != null)
                {
                    return root;
                }
                else
                {
                  throw new Exception("the node  is not existed");
                    //Console.Read();  
                }
            }
            catch (Exception e)
            {
                //显示错误信息  
                throw e;
            }
        }




        public static XmlNode FindNode(this XmlNode XmlNode, string node)
        {
          
            try
            {

                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                var root = XmlNode.SelectSingleNode(node);//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
                if (root != null)
                {
                    return root;
                }
                else
                {
                    throw new Exception("the node  is not existed");
                    //Console.Read();  
                }
            }
            catch (Exception e)
            {
                //显示错误信息  
                throw e;
            }
        }





    }
}
