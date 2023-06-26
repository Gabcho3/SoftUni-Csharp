function multiplicationTable(num){
    for(let multiplier = 1; multiplier <= 10; multiplier++){
        let result = num * multiplier;
        console.log(`${num} X ${multiplier} = ${result}`);
    }
}
multiplicationTable(5); //multiplication table of number 5
multiplicationTable(2); //multiplication table of number 2