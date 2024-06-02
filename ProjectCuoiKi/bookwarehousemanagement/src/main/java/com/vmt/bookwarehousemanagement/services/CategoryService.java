package com.vmt.bookwarehousemanagement.services;

import java.util.List;

import com.vmt.bookwarehousemanagement.entities.Category;

public interface CategoryService {

	public List<Category> findAllCategories();

	public Category findCategoryById(Long id);

	public void createCategory(Category category);

	public void updateCategory(Category category);

	public void deleteCategory(Long id);
	long countCategories();
}

