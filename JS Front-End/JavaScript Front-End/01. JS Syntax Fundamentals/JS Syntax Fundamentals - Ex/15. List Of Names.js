function listOfNames(names){
    names = names.sort();
    let num = 1;
    names.forEach(name => {
        console.log(`${num++}.${name}`);
    });
}
listOfNames(["John", "Bob","Christina","Ema"]); //1.Bob | 2.Christina | 3.Ema | 4.John