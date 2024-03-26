package thiGK.ntu63131330.services;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;
import thiGK.ntu63131330.models.SinhVien;

@Service
public interface SinhvienService {
    public Page<SinhVien> findPaginated(Pageable pageable);
	void addSinhVien(SinhVien sinhVien);
    SinhVien findByMSSV(String mssv);

}
