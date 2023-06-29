function calculate(...input){
    for (let i = 0; i < input.length; i++) {
        if(i % 2 !== 0){ //there is an operator
            let operator = input[i];
            let num1 = Number(input[i - 1]);
            let num2 = Number(input[i + 1]);
            let result = num1;

            switch(operator){
                case '+': result += num2; break;
                case '-': result -= num2; break;
                case '/': result /= num2; break;
                case '*': result *= num2; break;
            }
            console.log(result.toFixed(2));
        }
    }
}
calculate(5, '+', 10); //15.00
calculate(25.5, '-', 3); //22.50