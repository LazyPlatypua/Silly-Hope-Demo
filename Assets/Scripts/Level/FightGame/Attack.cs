//Структура атаки существ
[System.Serializable]
public struct Attack
{
    public string sender;       //кто наносит урон
    public string receiver;     //получатель урона
    public string attackName;  //имя атаки

    public Attack(string r, string a, string s = "knight(clone)")
    {
        sender = s;
        receiver = r;
        attackName = a;
    }
}
