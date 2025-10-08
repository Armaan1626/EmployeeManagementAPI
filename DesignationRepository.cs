namespace EmployeeManagementAPI
{
    public class DesignationRepository:IDesignation
    {
        private readonly ApplicationDbContext _context;
        public DesignationRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public List<Designation> GetAllDesignation()
        {
            return _context.Designations.ToList();
            ;
        }
        public Designation GetDesignation(int id)
        {
            return _context.Designations.Find(id);
        }

        public void DeleteDesignation(int id)
        {
            var desg = _context.Designations.Find(id);
            if (desg != null)
            {
                _context.Designations.Remove(desg);
                _context.SaveChanges();
            }

        }
        public void UpdateDesignation(Designation designation)
        {
            var existingDesignation = _context.Designations.Find(designation.DesignationId);
            if (existingDesignation != null)
            {
                if (designation.DesignationName != null)
                {
                    existingDesignation.DesignationName = designation.DesignationName;
                }

                _context.SaveChanges();
            }
        }

        public void InsertDesignation(CreateDesignationDto designationdto)
        {
            Designation designation = new Designation();
            designation.DesignationName = designationdto.DesignationName;
            _context.Designations.Add(designation);
            _context.SaveChanges();
        }
    }
}
