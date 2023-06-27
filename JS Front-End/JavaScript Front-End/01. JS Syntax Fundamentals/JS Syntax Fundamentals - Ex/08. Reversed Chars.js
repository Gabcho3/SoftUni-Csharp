function reverseChars(...chars){
    let reverseChars = [];
    while(chars.length > 0){
        reverseChars.push(chars.pop());
    }
    console.log(reverseChars.join(' '));
}
reverseChars('A', 'B', 'C'); //C B A
reverseChars('1', 'L', '&'); //& L 1