function solve() {
  const addButtonsDivs = Array.from(
    document.querySelectorAll(".product-add:not(label)")
  );
  const checkoutButton = document.querySelector("button.checkout");
  const listOfProducts = [];

  addButtonsDivs.forEach((buttonDiv) => {
    checkForAddingProduct(buttonDiv);
  });

  checkoutButton.addEventListener("click", checkout);

  function checkForAddingProduct(buttonDiv) {
    const addButton = buttonDiv.querySelector(".add-product");

    addButton.addEventListener("click", addProduct);

    function addProduct() {
      const productDiv = buttonDiv.parentElement;

      const name = productDiv.querySelector(".product-title").innerText;
      const price = Number(
        productDiv.querySelector(".product-line-price").innerText
      );

      const product = {
        name: name,
        price: price.toFixed(2),
        getProduct() {
          return `Added ${this.name} for ${this.price} to the cart.\n`;
        },
      };

      listOfProducts.push(product);
      document.querySelector("textarea").value += product.getProduct();
    }
  }

  function checkout() {
    const totalPrice = listOfProducts.reduce((acc, curr) => {
      return acc + Number(curr.price);
    }, 0);

    let productNames = new Set();
    listOfProducts.forEach((product) => {
      productNames.add(product.name);
    });

    productNames = Array.from(productNames);

    const output = `You bought ${productNames.join(", ")} for ${totalPrice}.`;
    document.querySelector("textarea").value += output;

    Array.from(document.querySelectorAll("button")).forEach((button) => {
      button.disabled = true;
    });
  }
}
