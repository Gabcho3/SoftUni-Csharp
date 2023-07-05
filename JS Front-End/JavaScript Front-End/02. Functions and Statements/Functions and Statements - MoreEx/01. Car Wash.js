const commands = {
    soap: (value) => value += 10,
    water: (value) => value *= 1.20,
    vacuumcleaner: (value) =>  value *= 1.25,
    mud: (value) => value *= 0.90
}

function carWash(input){
    const commands = {
        soap: (value) => value += 10,
        water: (value) => value *= 1.20,
        vacuumcleaner: (value) =>  value *= 1.25,
        mud: (value) => value *= 0.90
    }
    let value = 0;
    for(let i = 0; i < input.length; i++){
        const command = input[i];
        value = commands[command.replace(' ', '')](value);
    }
    console.log(`The car is ${value.toFixed(2)}% clean.`);
}
carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']) //39.00%
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]); //13.12%
