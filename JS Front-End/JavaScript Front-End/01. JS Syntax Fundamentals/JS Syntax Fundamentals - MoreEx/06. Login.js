function login(input){
    const user = input.shift();
    const password = Array.from(user).reverse().join('');
    
    let passwordTries = input.map(element => { return element; })
    tryToLog(user, password, passwordTries);
}
function tryToLog(user, password, passwordTries){
    let tries = 0;
    passwordTries.forEach(element => {
        if(element !== password){
            tries++;
            if(tries == 4){
                console.log(`User ${user} blocked!`);
                return;
            }
            console.log('Incorrect password. Try again.');
        } else{
            console.log(`User ${user} logged in.`);
            return;
        }
    });
}

login(['Acer','login','go','let me in','recA']);
login(['momo','omom']);
login(['sunny','rainy','cloudy','sunny','not sunny']);