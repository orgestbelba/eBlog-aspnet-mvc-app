using eBlog.Data.Static;
using eBlog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.Data
{
    public class AppDbInitializer
    {
        //Seeding the default data.
        public static void SeedPostsAndComments(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Post
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(new List<Post>()
                    {
                        new Post()
                        {
                            Category = PostCategory.Art,
                            Title = "Art Post",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ImagePath = "https://www.singulart.com/images/artworks/v2/cropped/22393/main/fhd/928699_b1952ff2e5f724c2cc7f4486cf00c126.jpeg",
                            PostTime = DateTime.Now.AddDays(-11),
                            UserId = context.Users.First(u => u.UserName == "user1").Id
                        },

                        new Post()
                        {
                            Category = PostCategory.Nature,
                            Title = "Nature Post",
                            Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                            ImagePath = "https://media.cntraveller.com/photos/62f3beac1394a0fa946ced39/4:3/w_2664,h_1998,c_limit/Albania%20-sept2022%20issue-jenny%20zarins14.jpg",
                            PostTime = DateTime.Now.AddDays(-20),
                            UserId = context.Users.First(u => u.UserName == "user2").Id
                        },

                        new Post()
                        {
                            Category = PostCategory.Politics,
                            Title = "Politics Post",
                            Text = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?",
                            ImagePath = "https://balkaninsight.com/wp-content/uploads/2019/06/Parlamenti-13-qershorweb-e1560502784533-1280x720.jpg",
                            PostTime = DateTime.Now.AddDays(-7),
                            UserId = context.Users.First(u => u.UserName == "user3").Id
                        },

                        new Post()
                        {
                            Category = PostCategory.Science,
                            Title = "Science Post",
                            Text = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                            ImagePath = "https://www.science-on-stage.eu/sites/default/files/images/foto_grupi_sos_albania.jpg",
                            PostTime = DateTime.Now.AddDays(-4),
                            UserId = context.Users.First(u => u.UserName == "user1").Id
                        },

                        new Post()
                        {
                            Category = PostCategory.Sport,
                            Title = "Sport Post",
                            Text = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                            ImagePath = "https://cdn.dmcl.biz/media/image/205100/o/GettyImages-541330924.jpg",
                            PostTime = DateTime.Now.AddDays(-1),
                            UserId = context.Users.First(u => u.UserName == "user3").Id
                        }
                    });

                    context.SaveChanges();
                }

                //Comment
                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(new List<Comment>()
                    {
                        new Comment()
                        {
                            TheComment = "Nice!",
                            CommentTime = DateTime.Now.AddDays(-10),
                            UserId = context.Users.First(u => u.UserName == "user1").Id,
                            PostID = context.Posts.First(p => p.Title == "Nature Post").PostID
                        },

                        new Comment()
                        {
                            TheComment = "Incredible!",
                            CommentTime = DateTime.Now.AddDays(-5),
                            UserId = context.Users.First(u => u.UserName == "user2").Id,
                            PostID = context.Posts.First(p => p.Title == "Art Post").PostID
                        },

                        new Comment()
                        {
                            TheComment = "Cool!",
                            CommentTime = DateTime.Now.AddDays(-1),
                            UserId = context.Users.First(u => u.UserName == "user3").Id,
                            PostID = context.Posts.First(p => p.Title == "Science Post").PostID
                        },

                        new Comment()
                        {
                            TheComment = "Lets Goo!",
                            CommentTime = DateTime.Now,
                            UserId = context.Users.First(u => u.UserName == "user2").Id,
                            PostID = context.Posts.First(p => p.Title == "Science Post").PostID
                        }
                    });

                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                
                //Admin
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //User1
                string appUserEmail = "user1@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        FirstName = "First",
                        LastName = "User",
                        UserName = "user1",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                //User2
                string userEmail2 = "user2@eblog.com";
                var user2 = await userManager.FindByEmailAsync(userEmail2);
                if (user2 == null)
                {
                    var newUser2 = new User()
                    {
                        FirstName = "Second",
                        LastName = "User",
                        UserName = "user2",
                        Email = userEmail2,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newUser2, "Coding@1234?");
                    await userManager.AddToRoleAsync(newUser2, UserRoles.User);
                }

                //User3
                string userEmail3 = "user3@eblog.com";
                var user3 = await userManager.FindByEmailAsync(userEmail3);
                if (user3 == null)
                {
                    var newUser3 = new User()
                    {
                        FirstName = "Third",
                        LastName = "User",
                        UserName = "user3",
                        Email = userEmail3,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newUser3, "Coding@1234?");
                    await userManager.AddToRoleAsync(newUser3, UserRoles.User);
                }
            }
        }

    }

}
