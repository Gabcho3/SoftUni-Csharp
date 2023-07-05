function findFactorial(num1, num2){
    let firstFactorial = 1;
    let secondFactorial = 1;
    for(let multiplier = num1; multiplier > 1; multiplier--){
        firstFactorial *= multiplier;
    }
    for(let multiplier = num2; multiplier > 1; multiplier--){
        secondFactorial *= multiplier;
    }
    const devision = firstFactorial / secondFactorial;
    console.log(devision.toFixed(2));
}
findFactorial(5, 2); //60.00
findFactorial(6, 2); //360.00

//Solution with recursion
// function calculateDevisionOfFactorials(num1, num2){
//     let firstFactorial = factorial(num1);
//     let secondFactorial = factorial(num2);  
//     function factorial(x){
//         if(x === 1){
//             return 1;
//         } else{
//             return x * factorial(x - 1);
//         }
//     }
//     const devision = firstFactorial / secondFactorial;
//     console.log(devision.toFixed(2));
// }