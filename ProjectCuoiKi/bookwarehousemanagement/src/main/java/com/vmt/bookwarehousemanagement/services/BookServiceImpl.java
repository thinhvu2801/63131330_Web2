package com.vmt.bookwarehousemanagement.services;

import java.util.List;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import com.vmt.bookwarehousemanagement.entities.Book;
import com.vmt.bookwarehousemanagement.exception.NotFoundException;
import com.vmt.bookwarehousemanagement.repositories.BookRepository;

@Service
public class BookServiceImpl implements BookService {

	private final BookRepository bookRepository;

	public BookServiceImpl(BookRepository bookRepository) {
		this.bookRepository = bookRepository;
	}

	@Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
	@Override
	public List<Book> findAllBooks() {
		return bookRepository.findAll();
	}

	@Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
	@Override
	public List<Book> searchBooks(String keyword) {
		if (keyword != null) {
			return bookRepository.search(keyword);
		}
		return bookRepository.findAll();
	}

	@Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
	@Override
	public Book findBookById(Long id) {
		return bookRepository.findById(id)
				.orElseThrow(() -> new NotFoundException(String.format("Book not found with ID %d", id)));
	}

	@Override
	public void createBook(Book book) {
		bookRepository.save(book);
	}

	@Override
	public void updateBook(Book book) {
		bookRepository.save(book);
	}

	@Override
	public void deleteBook(Long id) {
		final Book book = bookRepository.findById(id)
				.orElseThrow(() -> new NotFoundException(String.format("Book not found with ID %d", id)));

		bookRepository.deleteById(book.getId());
	}
	@Override
    public long countBooks() {
        return bookRepository.count();
    }
}
