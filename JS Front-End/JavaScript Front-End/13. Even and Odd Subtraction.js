function differenceBetweenOddAndEvenNums(numbers){
    let oddSum = 0;
    let evenSum = 0;
    for (let index = 0; index < numbers.length; index++) {
        let currNum = numbers[index];
        if(currNum % 2 === 0){
            evenSum += currNum;
        } else{
            oddSum += currNum;
        }
    }
    console.log(evenSum - oddSum);
}
differenceBetweenOddAndEvenNums([1,2,3,4,5,6]); //3
differenceBetweenOddAndEvenNums([3,5,7,9]); //-24
differenceBetweenOddAndEvenNums([2,4,6,8,10]); //30
