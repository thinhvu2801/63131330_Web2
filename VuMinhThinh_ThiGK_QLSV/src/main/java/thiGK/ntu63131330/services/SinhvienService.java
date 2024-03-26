package thiGK.ntu63131330.services;

import org.springframework.stereotype.Service;

import thiGK.ntu63131330.models.SinhVien;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
@Service
public interface SinhvienService {
	public Page<SinhVien> findPaginated(Pageable pageable);
     
   
}