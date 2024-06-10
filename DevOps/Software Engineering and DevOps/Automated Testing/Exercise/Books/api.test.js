const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const { exec } = require('child_process');
const expect = chai.expect;

chai.use(chaiHttp);

describe('Books API', () => {
  const testBook = { id: "1", title: "Test Book", author: "Test Author" };

  it("shoud be able to add a Book", (done) => {
    chai.request(server)
      .post("/books")
      .send(testBook)
      .end((err, res) => {
        expect(res).to.have.status(201);
        expect(res.body).to.be.a("object");
        expect(res.body.id).to.be.equal(testBook.id);
        expect(res.body.title).to.be.equal(testBook.title);
        expect(res.body.author).to.be.equal(testBook.author);
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
        expect(res.body[0].id).to.be.equal(testBook.id);
        done();
      });
  });

  it("should be able to get a Book by Id", (done) => {
    chai.request(server)
      .get(`/books/${testBook.id}`)
      .end((err, res) => {
        expect(res).to.have.status(200);
        expect(res.body).to.be.a("object");
        expect(res.body.id).to.be.equal(testBook.id);
        expect(res.body.title).to.be.equal(testBook.title);
        expect(res.body.author).to.be.equal(testBook.author);
        done();
      });
  });

});