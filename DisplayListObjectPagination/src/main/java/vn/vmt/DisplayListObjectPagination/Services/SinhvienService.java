package vn.vmt.DisplayListObjectPagination.Services;



import org.springframework.stereotype.Service;

import vn.vmt.DisplayListObjectPagination.Models.SinhVien;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
@Service
public interface SinhvienService {
	public Page<SinhVien> findPaginated(Pageable pageable);
     
   
}