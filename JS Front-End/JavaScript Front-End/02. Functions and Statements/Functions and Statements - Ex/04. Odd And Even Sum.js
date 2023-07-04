function calculateOddAndEvenSumOfDigitsFromNumber(number){
    let numToString = number.toString();
    let evenSum = 0;
    let oddSum = 0;
    for (let i = 0; i < numToString.length; i++) {
        const digit = Number(numToString[i]);
        if(digit % 2 === 0){
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
calculateOddAndEvenSumOfDigitsFromNumber(1000435);