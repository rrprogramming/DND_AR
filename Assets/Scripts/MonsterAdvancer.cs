using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterLib{

	public class MonsterAdvancer{

		public Monster AdvanceByHD(Monster monster){
			if(monster.getType() == 0 || monster.getType() == 1 || monster.getType() == 4 || monster.getType() == 6 || monster.getType() == 7 || monster.getType() == 11 || monster.getType() == 12 || monster.getType() == 14){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,8));
				monster.setBaseAttack((int)((monster.getHd()/4)*3));
			}else if(monster.getType() == 9){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,8));
				monster.setBaseAttack(monster.getHd());
			}else if(monster.getType() == 2 || monster.getType() == 10){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,10));
				monster.setBaseAttack((int)((monster.getHd()/4)*3));
			}else if(monster.getType() == 8){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,10));
				monster.setBaseAttack(monster.getHd());
			}else if(monster.getType() == 3){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,12));
				monster.setBaseAttack(monster.getHd());
			}else if(monster.getType() == 13){
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,12));
				monster.setBaseAttack((int)(monster.getHd()/2));
			}else{
				monster.setHd(monster.getHd()+1);
				monster.setHp(monster.getHp()+Random.Range(1,6));
				monster.setBaseAttack((int)(monster.getHd()/2));
			}

			return monster;
		}
	}
}