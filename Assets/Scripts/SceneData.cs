using UnityEngine;

[System.Serializable]
public class SceneData
{
    [SerializeField]
    private string  m_id   = null;
    public  string  ID  { get { return m_id; } }

    [SerializeField]
    private string  m_category  = null;
    public  string  Category    { get { return m_category; } }  

    [SerializeField]
    private string  m_parentId  = null;
    public  string  ParentId    { get { return m_parentId; } } 
}