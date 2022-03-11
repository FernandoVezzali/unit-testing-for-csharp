using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Json;
using System.Net;

namespace UnitTestCourse.Test
{

    public class TodoApiTests
    {
        [Fact]
        public async Task ShouldReturnHttpStatusCodeCreated()
        {
            // Arrange
            await using var application = new TodoApplication();

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/todos", new Todo { Title = "I want to do this thing tomorrow" });

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task ShouldFindTodoByTitle()
        {
            // Arrange
            await using var application = new TodoApplication();

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/todos", new Todo { Title = "I want to do this thing tomorrow" });

            var todos = await client.GetFromJsonAsync<List<Todo>>("/todos");

            // Assert
            Assert.Equal("I want to do this thing tomorrow", todos!.LastOrDefault()!.Title);
        }

        [Fact]
        public async Task ShouldFindOnlyOneItem()
        {
            // Arrange
            await using var application = new TodoApplication();

            var client = application.CreateClient();

            // Act
            await client.DeleteAsync("/todos/delete-all");

            var response = await client.PostAsJsonAsync("/todos", new Todo { Title = "I want to do this thing tomorrow" });

            var todos = await client.GetFromJsonAsync<List<Todo>>("/todos");

            // Assert
            Assert.Single(todos);
        }

        [Fact]
        public async Task ShouldDelete()
        {
            // Arrange
            await using var application = new TodoApplication();

            var client = application.CreateClient();

            // Act
            var response = await client.DeleteAsync("/todos/delete-all");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
