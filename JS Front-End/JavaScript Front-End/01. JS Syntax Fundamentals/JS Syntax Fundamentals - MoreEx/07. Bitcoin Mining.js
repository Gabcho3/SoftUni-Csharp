function bitcoinMining(goldAmounts){
    const bitcoinPrice = 11949.16;
    const gramOfGold = 67.51;

    let totalAmount = 0;
    let totalBitcoins = 0;
    let dayOfFirstPurchase = 0;
    for (let i = 1; i <= goldAmounts.length; i++) {
        let grams = goldAmounts[i - 1]; 
        
        if(i % 3 === 0){
            grams *= 0.70;
        }

        totalAmount += grams * gramOfGold;

        while(totalAmount >= bitcoinPrice){
            if(dayOfFirstPurchase == 0) { dayOfFirstPurchase = i; }
            totalAmount -= bitcoinPrice;
            totalBitcoins++;
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoins}`);
    if(dayOfFirstPurchase != 0) { console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchase}`); }
    console.log(`Left money: ${totalAmount.toFixed(2)} lv.`);
}

bitcoinMining([100, 200, 300]);
bitcoinMining([50, 100]);
bitcoinMining([3124.15, 504.212, 2511.124])