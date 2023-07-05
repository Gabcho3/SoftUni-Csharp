function modifyNumber(number){
    let numberToString = number.toString();
    let totalSum = 0;
    for (let i = 0; i < numberToString.length; i++) {
        const digit = Number(numberToString[i]);
        totalSum += digit;
    }
    let averageSum = totalSum / numberToString.length;
    while(averageSum <= 5){
        numberToString += '9';
        totalSum += 9;
        averageSum = totalSum / numberToString.length;
    }
    console.log(numberToString);
}
modifyNumber(101); //1019999