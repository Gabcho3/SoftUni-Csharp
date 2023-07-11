function createRegisterForHeroes(input){
    class Hero{
        constructor(name, level, items){
            this.name = name;
            this.level = level,
            this.items = items;
        }
        printHero(){
            console.log(`Hero: ${this.name}\nlevel => ${this.level}\nitems => ${this.items.join(', ')}`);
        }
    }

    let registerForHeroes = [];
    for(const element of input){
        const [name, level, items] = element.split(' / ');
        const hero = new Hero(name, Number(level), items.split(', '));
        registerForHeroes.push(hero);
    }
    registerForHeroes.sort((a, b) => {
        return a.level - b.level;
    });
    registerForHeroes.forEach(hero => hero.printHero());
}
createRegisterForHeroes([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );