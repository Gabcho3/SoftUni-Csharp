function charsToString(...chars){
    let charsToString = chars.toString();
    while(charsToString.includes(',')){
        charsToString = charsToString.replace(',', '');
    }
    console.log(charsToString);
}
charsToString('a', 'b', 'c'); //abc 
charsToString('1', '5', 'p'); //15p