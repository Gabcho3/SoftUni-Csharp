function validateDistance(x1, y1, x2, y2){
    const formula1 = Math.sqrt(Math.pow(0 - x1, 2) + Math.pow(0 - y1, 2));
    const formula2 = Math.sqrt(Math.pow(0 - x2, 2) + Math.pow(0 - y2, 2));
    const formula3 = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));

    let output1 = `{${x1}, ${y1}} to {0, 0} is ${Number.isInteger(formula1) ? 'valid' : 'invalid'}`;
    let output2 = `{${x2}, ${y2}} to {0, 0} is ${Number.isInteger(formula2) ? 'valid' : 'invalid'}`;
    let output3 = `{${x1}, ${y1}} to {${x2}, ${y2}} is ${Number.isInteger(formula3) ? 'valid' : 'invalid'}`;

    console.log(output1);
    console.log(output2);
    console.log(output3);
}

validateDistance(3, 0, 0, 4);
validateDistance(2, 1, 1, 1);