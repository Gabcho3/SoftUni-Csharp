function extractWords(string){
    let words = [];

    if(!string.includes(' ')){
        console.log(string.toUpperCase());
        return;
    }

    let wordToAdd = '';
    for (let i = 0; i < string.length; i++) {
        const element = string[i];

        if(!/\W/.test(element) && element !== ' '){
            wordToAdd += element;
        }else{
            if(wordToAdd.length > 0){
                words.push(wordToAdd.toUpperCase());
            }
            wordToAdd = '';
        }
    }
    console.log(words.join(', '));
}
extractWords('Hi, how are you?'); //HI, HOW, ARE, YOU
extractWords('hello'); //HELLO
extractWords('Functions in JS can be nested, i.e. hold other functions'); 
//FUNCTIONS, IN, JS, CAN, BE, NESTED, I, E, HOLD, OTHER, FUNCTIONS