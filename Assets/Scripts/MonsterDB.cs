using MonsterLib;

public class MonsterDB{

   public static Monster dragon, giant, owlbear;

   public static void init(){
        dragon = new RedDragon();
        giant = new HillGiant();
        owlbear = new OwlBear();
   }

}