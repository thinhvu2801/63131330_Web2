package com.vmt.bookwarehousemanagement.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import com.vmt.bookwarehousemanagement.services.BookService;
import com.vmt.bookwarehousemanagement.services.AuthorService;
import com.vmt.bookwarehousemanagement.services.CategoryService;
import com.vmt.bookwarehousemanagement.services.PublisherService;

@Controller
public class AdminController {

    private final BookService bookService;
    private final AuthorService authorService;
    private final CategoryService categoryService;
    private final PublisherService publisherService;

    public AdminController(BookService bookService, AuthorService authorService, 
                           CategoryService categoryService, PublisherService publisherService) {
        this.bookService = bookService;
        this.authorService = authorService;
        this.categoryService = categoryService;
        this.publisherService = publisherService;
    }

    @GetMapping("/admin/statistics")
    public String showStatistics(Model model) {
        model.addAttribute("totalBooks", bookService.countBooks());
        model.addAttribute("totalAuthors", authorService.countAuthors());
        model.addAttribute("totalCategories", categoryService.countCategories());
        model.addAttribute("totalPublishers", publisherService.countPublishers());
        return "admin-statistics";
    }
}
