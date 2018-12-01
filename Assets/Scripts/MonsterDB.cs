using MonsterLib;

public class MonsterDB{

   public static Monster dragon, giant, owlbear;

   public static void init(){
      dragon = new Monster("Red Dragon", 100, Size.Huge, Type.Dragon, SubType.Fire, 8, 8, 10);
      giant = new Monster("Hill Giant", 50, Size.Large, Type.Giant, SubType.Native, 2, 4, 4);
      owlbear = new Monster("Owlbear", 80, Size.Medium, Type.MagicalBeast, SubType.Lawful, 10, 2, 4);
   }

}