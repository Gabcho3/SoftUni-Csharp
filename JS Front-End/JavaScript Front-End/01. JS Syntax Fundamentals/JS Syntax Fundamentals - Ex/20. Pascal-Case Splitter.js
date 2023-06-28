function splitArray(string){
    let output = [];
    
    for (let i = 0; i < string.length; i++) {
        const element = string[i];
        
        if(/[A-Z]/.test(element)){
            let index = i + 1;
            let currWord = element;

            while(!/[A-Z]/.test(string[index]) && index < string.length){
                currWord += string[index];
                index++;
            }

            output.push(currWord);
            i += currWord.length - 1;
        }
    }

    console.log(output.join(', '));
}
splitArray('SplitMeIfYouCanHaHaYouCantOrYouCan');
splitArray('HoldTheDoor');
splitArray('ThisIsSoAnnoyingToDo');