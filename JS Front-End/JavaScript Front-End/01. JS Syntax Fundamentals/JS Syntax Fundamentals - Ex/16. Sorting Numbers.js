function sortNumbers(numbers){
    let output = [];
    numbers = numbers.sort(function(a, b){
        return a - b;
    });
    while(numbers.length > 0){
        output.push(numbers.shift());
        output.push(numbers.pop());
    }
    console.log(output);
}
sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]); //[-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]