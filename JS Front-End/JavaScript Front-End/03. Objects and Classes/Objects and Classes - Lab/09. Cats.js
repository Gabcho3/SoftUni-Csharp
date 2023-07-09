function createCat(input){
    class Cat{
        constructor(name, age){
            this.name = name;
            this.age = age;
        }
        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    const cats = input.map(data => {
        const [name, age] = data.split(' ');
        return new Cat(name, age);
    });

    cats.forEach(cat => cat.meow());
}
createCat(['Mellow 2', 'Tom 5']);