function createPyramid(base, increment){
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    const steps = Math.round(base / 2);
    
    for (let i = 1; i < steps; i++) {
        const parameter = Math.pow(base, 2);
        const currStone = Math.pow(base - 2, 2);
        
        if(i % 5 === 0){
            lapis += (parameter - currStone) * increment;
        } else{
            marble += (parameter - currStone) * increment;
        }

        stone += currStone * increment;
        base -= 2;
    }
    const gold = Math.pow(base, 2) * increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);

    const height = steps * increment;
    console.log(`Final pyramid height: ${Math.floor(height)}`);
}

createPyramid(11, 1);
createPyramid(11, 0.75)
createPyramid(12, 1);
createPyramid(23, 0.5);