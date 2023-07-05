function createLoadingBar(percentage){
    let loadingBar = `${percentage}% [..........]`;
    let times = percentage / 10;
    loadingBar = loadingBar.replace('.'.repeat(times), '%'.repeat(times));

    if(percentage === 100){
        console.log(`${percentage}% Complete!`);
        console.log(loadingBar.substring(5, loadingBar.length));
    } else{
        console.log(loadingBar);
        console.log('Still loading...');
    }
}
createLoadingBar(30);
createLoadingBar(100)