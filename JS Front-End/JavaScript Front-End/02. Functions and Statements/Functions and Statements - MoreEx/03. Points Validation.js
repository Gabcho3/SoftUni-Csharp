function validateDistance(input){
    const x1 = Number(input[0]);
    const y1 = Number(input[1]);
    const x2 = Number(input[2]);
    const y2 = Number(input[3]);

    function formula(x1, y1, x2, y2){
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    }

    let output1 = `{${x1}, ${y1}} to {0, 0} is ${Number.isInteger(formula(x1, y1, 0, 0)) ? 'valid' : 'invalid'}`;
    let output2 = `{${x2}, ${y2}} to {0, 0} is ${Number.isInteger(formula(x2, x2, 0, 0)) ? 'valid' : 'invalid'}`;
    let output3 = `{${x1}, ${y1}} to {${x2}, ${y2}} is ${Number.isInteger(formula(x1, y1, x2, y2)) ? 'valid' : 'invalid'}`;

    console.log(output1);
    console.log(output2);
    console.log(output3);
}

validateDistance([3, 0, 0, 4]);
validateDistance([2, 1, 1, 1]);