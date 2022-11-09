using Final19.BLL.Exceptions;
using Final19.BLL.Models;
using Final19.DAL.Entities;
using Final19.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Final19.BLL.Services
{
    public class UserService
    {
        MessageService messageService;
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
            friendRepository = new FriendRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();
            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();
            EmailValid(userRegistrationData.Email);
            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };
            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();

        }

        public void EmailValid(string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentNullException();
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();
            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();
            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();
            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };
            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);
            var friends = GetListFrendsByUserId(userEntity.id);
            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages,
                          friends
                          );
        }

        public void AddToFriends(Friend friend)
        {
            var friendEntity = new FriendEntity
            {
                user_id = friend.User_id,
                friend_id = friend.Friend_id
            };
            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<User> GetListFrendsByUserId(int userId)
        {
            var friends = new List<User>();
            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var userFriend = userRepository.FindById(f.friend_id);
                friends.Add(new User(0,
                                    userFriend.firstname,
                                    userFriend.lastname,
                                    null,
                                    userFriend.email,
                                    userFriend.photo,
                                    userFriend.favorite_movie,
                                    userFriend.favorite_book,
                                    null,
                                    null,
                                    null));
            });
            return friends;
        }

        public void DeleteFriend(Friend friend)
        {
            this.friendRepository.Delete(friend.Friend_id);
        }

        public int Multiplication(int x, int y) => x + y;
    }
}