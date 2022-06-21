using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Model;

namespace test_api.Repository
{
    public class UserPermissionRepository
    {
        // Uzupełnianie listy ("tabeli") uprawnieniami przypisanymi do poszczególnych userów
        private static List<UserPermission> UserPermissions = new List<UserPermission> {
                        new UserPermission(1, 2, 1),    // pierwszy wpis (o id = 1) dla użytkownika (o id = 2) przechowuje uprawnienia administracyjne (o id = 1)
                        new UserPermission(2, 1, 2)};   // drugi wpis (o id = 2) dla użytkownika (o id = 1) przechowuje uprawnienia pracownicze (o id = 2)

        internal bool HasAdminPermission(long userId)
        {
            foreach(UserPermission userPermission in UserPermissions)
            {
                if (userPermission.UserId == userId && userPermission.PermissionId == 1)
                {
                    // Jeśli uprawnienie o id = 1 (administrator) dla użytkownika o id = userId istnieje to zwraca true
                    return true;
                }
            }
            // w przeciwnym razie zwraca false
            return false;
        }

        public UserPermission Add(UserPermission userPermission)
        {
            long lastId = 0;
            if (UserPermissions.Count > 0)
            {
                // Jeśli jest już jakieś uprawnienie, to pobiera ostatnie (największe) id
                lastId = UserPermissions.Max(l => l.Id);
            }
            lastId++; // zwiększa id o 1

            userPermission.Id = lastId;   // przypisuje to id do nowego uprawnienia użytkownika

            UserPermissions.Add(userPermission); // dodaje nowe uprawnienie do "bazy"

            return userPermission;    // zwraca nowo utworzone uprawnienie użytkownika (wynika to z charakterystyki metody POST (HTTP))
        }
    }
}
