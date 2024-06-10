const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const { exec } = require('child_process');
const expect = chai.expect;

chai.use(chaiHttp);

describe('Books API', () => {
  const bookId = "1";

  it("shoud be able to add a Book", (done) => {
    const book = { id: bookId, title: "Test Book", author: "Test Author" };

    chai.request(server)
      .post("/books")
      .send(book)
      .end((err, res) => {
        expect(res).to.have.status(201);
        expect(res.body).to.be.a("object");
        expect(res.body.id).to.be.equal(book.id);
        expect(res.body.title).to.be.equal(book.title);
        expect(res.body.author).to.be.equal(book.author);
        done();
      });
  });

  it("should be able to get all Books", (done) => {
    chai.request(server)
      .get("/books")
      .end((err, res) => {
        expect(res).to.have.status(200);
        expect(res.body).to.be.a("array");
        expect(res.body.length).to.be.equal(1);
        expect(res.body[0].id).to.be.equal(bookId);
        done();
      });
  });

});