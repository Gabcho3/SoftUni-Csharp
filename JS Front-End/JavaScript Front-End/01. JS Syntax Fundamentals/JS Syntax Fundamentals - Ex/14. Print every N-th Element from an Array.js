function printByStep(array, step){
    let output = [];
    for(let i = 0; i < array.length; i += step){
        output.push(array[i]);
    }
    console.log(output);
}
printByStep(['5','20','31','4','20'], 2); //['5', '31', '20']
printByStep(['1', '2', '3', '4', '5'], 6); //['1']