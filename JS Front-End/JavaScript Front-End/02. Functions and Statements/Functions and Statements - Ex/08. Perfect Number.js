function checkIfNumberIsPerfect(number){
    let sum = 0;
    for(let divider = 1; divider < number; divider++){
        if(number % divider === 0){
            sum += divider;
        }
        if(sum === number){
            console.log('We have a perfect number!');
            return;
        }
    }
    console.log('It\'s not so perfect.');
}
checkIfNumberIsPerfect(6);