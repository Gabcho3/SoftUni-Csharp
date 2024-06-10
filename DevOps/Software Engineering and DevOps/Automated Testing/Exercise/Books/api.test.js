const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
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

  it("should be able to update a Book by Id", (done) => {
    const updatedBook = { id: testBook.id, title: "My Book", author: testBook.author};

    chai.request(server)
      .put(`/books/${testBook.id}`)
      .send(updatedBook)
      .end((err, res) => {
        expect(res).to.have.status(200);
        expect(res.body).to.be.a("object");
        expect(res.body.id).to.be.equal(updatedBook.id);
        expect(res.body.title).to.be.equal(updatedBook.title);
        expect(res.body.author).to.be.equal(updatedBook.author);
        done();
      });
  });

  it("should be able to delete a book by Id", (done) => {
    chai.request(server)
      .delete(`/books/${testBook.id}`)
      .end((err, res) => {
        expect(res).to.have.status(204); //Verify that no content was returned
        done();
      });
  });

  it("should not be able to perform HTTP actions with a non-existing book", (done) => {
    const bookId = "999";

    chai.request(server)
      .get(`/books/${bookId}`)
      .end((err, res) => {
        expect(res).to.have.status(404);
      });

      chai.request(server)
      .put(`/books/${bookId}`)
      .send({id : bookId, title : "Non-Existing Book", author: "Non-Existing Author"})
      .end((err, res) => {
        expect(res).to.have.status(404);
      });

      chai.request(server)
      .delete(`/books/${bookId}`)
      .end((err, res) => {
        expect(res).to.have.status(404);
        done();
      });
  });

});