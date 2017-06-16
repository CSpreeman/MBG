(function () {
    angular
        .module('mitmApp')
        .factory('blogService', BlogService);

    BlogService.$inject = ['$http'];

    function BlogService($http) {
        return {
            getBlogs: _getBlogs,
            getBlogById: _getBlogById,
            postBlog: _postBlog
        };

        function _getBlogs() {
            return $http.get('/api/blog')
                .then(getBlogsComplete)
                .catch(getBlogsFailed);

            function getBlogsComplete(response) {
                return response;
            }

            function getBlogsFailed(error) {
                console.log('Failed to get data', error);
            }
        }

        function _getBlogById(id) {
            return $http.get('/api/blog/' + id)
                .then(getBlogByIdComplete)
                .catch(getBlogByIdFailed);

            function getBlogByIdComplete(response) {
                return response;
            }

            function getBlogByIdFailed(error) {
                console.log('Failed to get data', error);
            }

        }

        function _postBlog(data) {
            return $http.post('/api/blog', data)
                .then(postBlogComplete)
                .catch(postBlogFailed);

            function postBlogComplete(response) {
                return response;
            }

            function postBlogFailed(error) {
                console.log('Failed to get data', error);
            }


        }
    }

})();



