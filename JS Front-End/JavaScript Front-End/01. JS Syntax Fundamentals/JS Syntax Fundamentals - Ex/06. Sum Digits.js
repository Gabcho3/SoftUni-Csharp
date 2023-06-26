function sumDigits(num){
    let numberToArray = Array.from(num.toString());
    let sum = 0;
    numberToArray.forEach(element => sum += Number(element));
    console.log(sum);
}
sumDigits(245678); //32
sumDigits(97561); //28
sumDigits(543); //12