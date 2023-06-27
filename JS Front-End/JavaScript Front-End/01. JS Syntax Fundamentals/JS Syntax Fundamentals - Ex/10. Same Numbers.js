function hasSameNumbers(number){
    number = number.toString();
    let firstNum = number[0];
    let areSame = number.includes(firstNum.repeat(number.length));
    let sum = 0;
    for(let i = 0; i < number.length; i++){
        sum += Number(number[i]);
    }
    console.log(areSame);
    console.log(sum);
}
hasSameNumbers(2222222); //true | 14
hasSameNumbers(1234); //false | 10