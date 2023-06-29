class Prices{
    constructor(input){
        this.lostFights = Number(input[0]);
        this.helmetPrice = Number(input[1]);
        this.swordPrice = Number(input[2]);
        this.shieldPrice = Number(input[3]);
        this.armorPrice = Number(input[4]);
    }
}

function calculateExpenses(...input){
    const prices = new Prices(input);

    let expenses = 0;
    let shieldsCount = 0;

    for (let i = 1; i <= prices.lostFights; i++) {
        if(i % 2 === 0){
            expenses += prices.helmetPrice;
        }
        if(i % 3 === 0){
            expenses += prices.swordPrice;
            if(i % 2 === 0){
                expenses += prices.shieldPrice
                shieldsCount++;
            }
        }

        if(shieldsCount === 2){
            expenses += prices.armorPrice;
            shieldsCount = 0;
        }
    }

    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

calculateExpenses(7, 2, 3, 4, 5); //Gladiator expenses: 16.00 aureus
calculateExpenses(23, 12.50, 21.50, 40, 200); //Gladiator expenses: 608.00 aureus