function passwordValidator(password){
    let isBetweenSixAndtenChars = /^\S{6,10}$/.test(password);
    let hasOnlyDigitsAndLetters = /^[A-Za-z\d]+$/.test(password);
    let hasAtLeastTwoDigits = /\d{2,}/.test(password);
    
    if(isBetweenSixAndtenChars && hasOnlyDigitsAndLetters && hasAtLeastTwoDigits){
        console.log('Password is valid');
        return;
    }

    if(!isBetweenSixAndtenChars){
        console.log('Password must be between 6 and 10 characters');
    }

    if(!hasOnlyDigitsAndLetters){
        console.log('Password must consist only of letters and digits');
    }

    if(!hasAtLeastTwoDigits){
        console.log('Password must have at least 2 digits');
    }
}
passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');