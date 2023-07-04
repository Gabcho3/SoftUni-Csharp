function findIfIntegersArePalindrome(integers){
    let booleans = [];
    integers.forEach(integer => {
        let integerToString = integer.toString();
        let reversedInteger = '';
        for (let i = integerToString.length - 1; i >= 0; i--) {
            reversedInteger += integerToString[i];
        }
        booleans.push(integerToString === reversedInteger);
    });

    console.log(booleans.join('\n'));
}
findIfIntegersArePalindrome([123,323,421,121]);
findIfIntegersArePalindrome([32,2,232,1010]);