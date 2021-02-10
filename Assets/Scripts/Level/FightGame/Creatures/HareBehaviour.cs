//Класс отвечает за поведение зайца

using Level.FightGame;

public class HareBehaviour : EnemyBehaviour
{
    //вместо атаки заяц убегает
    public override void Attack(Attack a)
    {
        RuningOut();
    }
    //зайца нельзя оглушить
    protected override void Stun()
    {
    }

    protected override void SetAllAnimToFalse()
    {
        animator.SetBool("take_damage", false);
    }
}
