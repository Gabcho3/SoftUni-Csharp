function sum(num1, num2, num3){
    let sum = num1 + num2;
    function subtract(sum, num3){
        return sum - num3;
    }
    return subtract(sum, num3)
}
console.log(sum(23, 6, 10)); //19