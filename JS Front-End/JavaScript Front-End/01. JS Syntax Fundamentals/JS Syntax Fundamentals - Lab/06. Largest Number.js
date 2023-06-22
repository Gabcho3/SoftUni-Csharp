function largestNumber(num1, num2, num3){
    let largestNumber = num1 > num2 && num1 > num3 ? num1 
        : num2 > num1 && num2 > num3 ? num2 
        : num3;

    console.log('The largest number is ' + largestNumber + '.');
}