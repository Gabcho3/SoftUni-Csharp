function printCharsInRange(firstChar, lastChar){
    let chars = [];

    let firstInt = firstChar.charCodeAt(0);
    let lastInt = lastChar.charCodeAt(0);

    if(firstChar < lastChar){
        for(let i = firstInt + 1; i < lastInt; i++){
            const element = String.fromCharCode(i)
            chars.push(element);
        }
    } else{
        for(let i = lastInt + 1; i < firstInt; i++){
            const element = String.fromCharCode(i);
            chars.push(element);
        }
    }
    console.log(chars.join(' '));
}
printCharsInRange('C', '#')